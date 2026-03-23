function agregar() {
    const lista = document.getElementById("lista");

    let cantidad = lista.children.length;
    let element = document.createElement("li");
    
    element.textContent = "Elemento" + (cantidad+1);
    lista.appendChild(element);
} 
function cambiarFondo() {
    const color = window.getComputedStyle(document.body).backgroundColor;

    if (color == "rgb(255, 255, 255)") {
        document.body.style.backgroundColor = 'teal';
    }
    else {
        document.body.style.backgroundColor = 'white';
    }
}
function borrar() {
    const lista = document.getElementById("lista");
    if (lista.children.length > 0) {
        lista.removeChild(lista.lastElementChild);
    }
} 