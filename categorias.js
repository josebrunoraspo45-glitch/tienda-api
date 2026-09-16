console.log("El JS se está ejecutando");

const API_URL = "http://localhost:5207/api/categorias";

async function cargarCategorias() {
    console.log("Entré a cargarCategorias");

    const respuesta = await fetch(API_URL);
    console.log("Respuesta recibida:", respuesta);

    const categorias = await respuesta.json();
    console.log("Categorías:", categorias);

    const tabla = document.getElementById("tablaCategorias");
    tabla.innerHTML = "";

    categorias.forEach(function (categoria) {
        tabla.innerHTML += `
            <tr>
                <td>${categoria.id}</td>
                <td>${categoria.nombre}</td>
                <td>${categoria.descripcion}</td>
            </tr>
        `;
    });

    console.log("Tabla llena");
}

cargarCategorias();