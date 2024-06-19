mergeInto(LibraryManager.library, {
    IsMobile: function () {
        var ua = window.navigator.userAgent.toLowerCase();
        var mobilePattern = /android|iphone|ipad|ipod/i;

        return ua.search(mobilePattern) !== -1 || (ua.indexOf("macintosh") !== -1 && "ontouchend" in document);
    },
    
       IsIOSBrowser: function () {
        return (/iPhone|iPad|iPod/i.test(navigator.userAgent));
      },
      IsAndroidBrowser: function () {
        return (/Android/i.test(navigator.userAgent));
      },

});
