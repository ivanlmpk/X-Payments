function MostrarMensagemSucesso(mensagem) {
    alert(mensagem);
}

let menuVisivel;
let btnToggleClick = false;

document.addEventListener('DOMContentLoaded', function () {

    function atualiazaVisibilidadeMenu() {
        navMenu.style.display = menuVisivel ? "block" : "none";
    }

    window.addEventListener('resize', function () {
        if (window.innerWidth <= 640 && btnToggleClick === false) {
            menuVisivel = false;
        } else {
            menuVisivel = true;
        }
        atualiazaVisibilidadeMenu();
    });

    window.addEventListener('resize', function () {
        if (window.innerWidth >= 641)
            btnToggleClick = false;
    });
});

function visibilidadeMenu() {
    var navMenu = document.getElementById('navMenu');

    if (navMenu.style.display === 'none' || navMenu.style.display === '') {
        navMenu.style.display = 'block';

        btnToggleClick = true;
    } else {
        navMenu.style.display = 'none';
        btnToggleClick = false;
    }
}


