// wwwroot/js/videoInterop.js

// Función para reproducir el video
window.playVideo = (videoElement) => {
    if (videoElement) {
        videoElement.play();
    }
};

// Función para pausar el video
window.pauseVideo = (videoElement) => {
    if (videoElement) {
        videoElement.pause();
    }
};

// Función para establecer el volumen
window.setVideoVolume = (videoElement, volume) => {
    if (videoElement) {
        videoElement.volume = volume;
    }
};

// Función para alternar la pantalla completa
window.toggleFullscreen = (videoElement) => {
    if (videoElement) {
        if (videoElement.requestFullscreen) {
            videoElement.requestFullscreen();
        } else if (videoElement.mozRequestFullScreen) { // Firefox
            videoElement.mozRequestFullScreen();
        } else if (videoElement.webkitRequestFullscreen) { // Chrome, Safari and Opera
            videoElement.webkitRequestFullscreen();
        } else if (videoElement.msRequestFullscreen) { // IE/Edge
            videoElement.msRequestFullscreen();
        }
    }
};

window.setupVideoEndedListener = (videoElement, component) => {
    if (videoElement) {
        // Elimina cualquier 'escuchador' anterior para evitar duplicados
        // (Esto es una buena práctica para prevenir errores)
        if (videoElement.__blazorVideoEndedListener) {
            videoElement.removeEventListener('ended', videoElement.__blazorVideoEndedListener);
        }

        // Define el nuevo 'escuchador'
        const listener = () => {
            // Llama al método de C# 'OnVideoEnded' en el componente Blazor
            component.invokeMethodAsync('OnVideoEnded');
        };

        // Agrega el 'escuchador' y guarda una referencia a él
        videoElement.addEventListener('ended', listener);
        videoElement.__blazorVideoEndedListener = listener;
    }
};