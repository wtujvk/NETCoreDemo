seajs.config({
    base: '/Assets/sea-modules/',
    alias: {
        'jquery': 'jquery/1.10.1/jquery',
        'json': 'json/1.0.1/json',
        'md5': 'gallery/blueimp-md5/1.1.0/md5',
        'raphael': 'gallery/raphael/2.1.2/raphael',
        'underscore': 'gallery/underscore/1.6.0/underscore'
    },
    preload: [this.JSON ? '' : 'json']
});