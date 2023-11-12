// Espera a que la estructura del DOM esté completamente cargada
document.addEventListener("DOMContentLoaded", function () {
    // Realiza la petición (fetch) de datos desde la API
    fetch("https://localhost:7270/api/Tabla")
        .then(response => {
            // Verifica si la respuesta es exitosa
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            // Convierte la respuesta a formato JSON
            return response.json();
        })
        .then(data => {
            // Verifica si 'data' es un array antes de iterar
            if (Array.isArray(data)) {
                // Obtener la tabla y el cuerpo de la tabla
                const librosTable = document.getElementById("librosTableBody");

                // Itera sobre los datos y agrega filas a la tabla
                data.forEach(libro => {
                    const newRow = document.createElement("tr");
                    newRow.innerHTML = `
                        <td>${libro.title}</td>
                        <td>${libro.authorName}</td>
                        <td>${libro.chapters}</td>
                        <td>${libro.pages}</td>
                        <td>${libro.price}</td>
                    `;
                    librosTable.appendChild(newRow);
                });
            } else {
                console.error("La respuesta no es un array:", data);
            }
        })
        .catch(error => console.error("Error al obtener los datos de los libros:", error));
});

// Función para la barra de búsqueda por título
function searchBooks() {
    // Obtenemos lo que se escribe en la barra de búsqueda
    const input = document.getElementById("searchInput");
    // Convertir a mayúsculas para una comparación sin distinción de mayúsculas y minúsculas
    const filter = input.value.toUpperCase();
    // Obtener la tabla y las filas de la tabla
    const table = document.getElementById("librosTableBody");
    const rows = table.getElementsByTagName("tr");

    // Iterar sobre las filas de la tabla
    for (let i = 0; i < rows.length; i++) {
        // Obtener la columna del título
        const titleCol = rows[i].getElementsByTagName("td")[0];

        if (titleCol) {
            // Convertir a mayúsculas
            const titleValue = titleCol.textContent || titleCol.innerText;

            // Verificar si el libro que buscamos se encuentra
            if (titleValue.toUpperCase().indexOf(filter) > -1) {
                // Mostrar la fila con el nombre del libro si se encuentra
                rows[i].style.display = "";
            } else {
                // Ocultar la fila si la búsqueda no coincide
                rows[i].style.display = "none";
            }
        }
    }
}
