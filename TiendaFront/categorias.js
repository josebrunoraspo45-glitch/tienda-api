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
                    <button onclick="editarCategoria(${categoria.id}, '${categoria.nombre}', '${categoria.descripcion}')">Editar</button>
                    <button onclick="eliminarCategoria(${categoria.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

async function crearCategoria() {
    const id = document.getElementById("editId").value;
    const nombre = document.getElementById("nombre").value;
    const descripcion = document.getElementById("descripcion").value;

    const categoria = { nombre: nombre, descripcion: descripcion };

    if (id === "") {
        await fetch(API_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(categoria)
        });
    } else {
        categoria.id = parseInt(id);
        await fetch(`${API_URL}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(categoria)
        });
    }

    document.getElementById("editId").value = "";
    document.getElementById("nombre").value = "";
    document.getElementById("descripcion").value = "";

    cargarCategorias();
}

function editarCategoria(id, nombre, descripcion) {
    document.getElementById("editId").value = id;
    document.getElementById("nombre").value = nombre;
    document.getElementById("descripcion").value = descripcion;
}

async function eliminarCategoria(id) {
    await fetch(`${API_URL}/${id}`, {
        method: "DELETE"
    });

    cargarCategorias();
}

cargarCategorias();