const API_URL = "http://localhost:5207/api/categorias";

async function cargarCategorias() {
    const respuesta = await fetch(API_URL);
    const categorias = await respuesta.json();

    const tabla = document.getElementById("tablaCategorias");
    tabla.innerHTML = "";

    categorias.forEach(function (categoria) {
        tabla.innerHTML += `
            <tr>
                <td>${categoria.id}</td>
                <td>${categoria.nombre}</td>
                <td>${categoria.descripcion}</td>
                <td>
                    <button onclick="eliminarCategoria(${categoria.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

async function crearCategoria() {
    const nombre = document.getElementById("nombre").value;
    const descripcion = document.getElementById("descripcion").value;

    const nuevaCategoria = {
        nombre: nombre,
        descripcion: descripcion
    };

    await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(nuevaCategoria)
    });

    document.getElementById("nombre").value = "";
    document.getElementById("descripcion").value = "";

    cargarCategorias();
}

async function eliminarCategoria(id) {
    await fetch(`${API_URL}/${id}`, {
        method: "DELETE"
    });

    cargarCategorias();
}

cargarCategorias();