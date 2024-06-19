mergeInto(LibraryManager.library, {
     IsIOSBrowser: function () {
        return (/iPhone|iPad|iPod/i.test(navigator.userAgent));
      },
      IsAndroidBrowser: function () {
        return (/Android/i.test(navigator.userAgent));
      },
      IsDesktopBrowser__deps: ['IsIOSBrowser', 'IsAndroidBrowser'],
      IsDesktopBrowser: function () {
        return !_IsIOSBrowser() && !_IsAndroidBrowser();
      },
      
});
