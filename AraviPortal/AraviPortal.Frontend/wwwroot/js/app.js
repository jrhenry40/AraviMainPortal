window.setupVideoEndedListener = (videoElement, dotNetHelper) => {
    if (videoElement) {
        videoElement.addEventListener('ended', () => {
            console.log('Video has ended!');
            // Invocar el método VideoEnded en el componente Blazor
            dotNetHelper.invokeMethodAsync('VideoEnded');
        });
    }
};