let lastTime = 0;
let seeking = false;
const videoStates = new Map();

window.playVideo = (videoElement) => {
    if (videoElement) {
        videoElement.play();
    }
};

window.pauseVideo = (videoElement) => {
    if (videoElement) {
        videoElement.pause();
    }
};

window.setVideoVolume = (videoElement, volume) => {
    if (videoElement) {
        videoElement.volume = volume;
    }
};

window.toggleFullscreen = (videoElement) => {
    if (videoElement) {
        if (videoElement.requestFullscreen) {
            videoElement.requestFullscreen();
        } else if (videoElement.mozRequestFullScreen) {
            videoElement.mozRequestFullScreen();
        } else if (videoElement.webkitRequestFullscreen) {
            videoElement.webkitRequestFullscreen();
        } else if (videoElement.msRequestFullscreen) {
            videoElement.msRequestFullscreen();
        }
    }
};

window.setupVideoEndedListener = (videoElement, component) => {
    if (videoElement) {
        if (!videoStates.has(videoElement)) {
            videoStates.set(videoElement, { lastTime: 0, seeking: false });
        }
        const state = videoStates.get(videoElement);

        if (videoElement.__blazorVideoEndedListener) {
            videoElement.removeEventListener('ended', videoElement.__blazorVideoEndedListener);
        }

        const endedListener = () => {
            component.invokeMethodAsync('OnVideoEnded');
        };
        videoElement.addEventListener('ended', endedListener);
        videoElement.__blazorVideoEndedListener = endedListener;

        if (!videoElement.__blazorPreventSeekListenersAdded) {
            const timeUpdateListener = () => {
                if (!state.seeking && videoElement.currentTime > state.lastTime + 1) {
                    videoElement.currentTime = state.lastTime;
                }
                state.lastTime = videoElement.currentTime;
            };
            videoElement.addEventListener('timeupdate', timeUpdateListener);

            const seekingListener = () => {
                state.seeking = true;
            };
            videoElement.addEventListener('seeking', seekingListener);

            const seekedListener = () => {
                state.seeking = false;
            };
            videoElement.addEventListener('seeked', seekedListener);

            videoElement.__blazorPreventSeekListenersAdded = true;
        }

        const playListener = () => {
            state.lastTime = videoElement.currentTime;
        };
        videoElement.addEventListener('play', playListener);
        videoElement.__blazorPlayListener = playListener;

        const canPlayListener = () => {
            state.lastTime = videoElement.currentTime;
        };
        videoElement.addEventListener('canplaythrough', canPlayListener);
        videoElement.__blazorCanPlayListener = canPlayListener;
    }
};

window.cleanupVideoListeners = (videoElement) => {
    if (videoElement) {
        if (videoElement.__blazorVideoEndedListener) {
            videoElement.removeEventListener('ended', videoElement.__blazorVideoEndedListener);
            delete videoElement.__blazorVideoEndedListener;
        }
        if (videoElement.__blazorPreventSeekListenersAdded) {
            delete videoElement.__blazorPreventSeekListenersAdded;
        }
        if (videoElement.__blazorPlayListener) {
            videoElement.removeEventListener('play', videoElement.__blazorPlayListener);
            delete videoElement.__blazorPlayListener;
        }
        if (videoElement.__blazorCanPlayListener) {
            videoElement.removeEventListener('canplaythrough', videoElement.__blazorCanPlayListener);
            delete videoElement.__blazorCanPlayListener;
        }
        videoStates.delete(videoElement);
    }
};