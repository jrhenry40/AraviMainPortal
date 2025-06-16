window.videoInterop = {
    // Stores the last valid (non-seeking) time
    _supposedCurrentTime: 0,
    _videoElement: null,
    _dotNetHelper: null,
    _videoEndedHandler: null,
    _timeUpdateHandler: null,
    _seekingHandler: null,

    initializeVideoEndedEvent: (videoElement, dotNetHelper) => {
        if (videoElement) {
            videoInterop._videoElement = videoElement;
            videoInterop._dotNetHelper = dotNetHelper;

            // Save handlers to allow proper removal later
            videoInterop._videoEndedHandler = function () {
                dotNetHelper.invokeMethodAsync('VideoHasEnded');
            };
            videoInterop._timeUpdateHandler = function () {
                // Only update supposedCurrentTime if not seeking
                if (!videoElement.seeking) {
                    videoInterop._supposedCurrentTime = videoElement.currentTime;
                }
            };
            videoInterop._seekingHandler = function () {
                // If the user tries to seek forward, revert to the last valid time
                const delta = videoElement.currentTime - videoInterop._supposedCurrentTime;
                // Allow a small delta to account for floating point inaccuracies
                if (delta > 0.1) { // 0.1 seconds tolerance
                    videoElement.currentTime = videoInterop._supposedCurrentTime;
                }
            };

            videoElement.addEventListener('ended', videoInterop._videoEndedHandler);
            videoElement.addEventListener('timeupdate', videoInterop._timeUpdateHandler);
            videoElement.addEventListener('seeking', videoInterop._seekingHandler);
        }
    },

    disposeVideoEndedEvent: (videoId) => {
        const videoElement = document.getElementById(videoId);
        if (videoElement) {
            // Remove all event listeners to prevent memory leaks
            if (videoInterop._videoEndedHandler) {
                videoElement.removeEventListener('ended', videoInterop._videoEndedHandler);
            }
            if (videoInterop._timeUpdateHandler) {
                videoElement.removeEventListener('timeupdate', videoInterop._timeUpdateHandler);
            }
            if (videoInterop._seekingHandler) {
                videoElement.removeEventListener('seeking', videoInterop._seekingHandler);
            }

            // Dispose DotNetObjectReference
            if (videoInterop._dotNetHelper) {
                videoInterop._dotNetHelper.dispose();
            }

            // Reset internal state
            videoInterop._videoElement = null;
            videoInterop._dotNetHelper = null;
            videoInterop._videoEndedHandler = null;
            videoInterop._timeUpdateHandler = null;
            videoInterop._seekingHandler = null;
            videoInterop._supposedCurrentTime = 0;
        }
    }
};