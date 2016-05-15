module.exports = function () {
  
    var src = './src/';
    var client = src + 'client/';
    var clientApp = client + 'app/';
    var temp = './.tmp/';
    var server = './src/server/';
    var config = {
        /**
         * Files paths
         */
        alljs: [
            './src/**/**/*.js'
        ],
        build: './build/',
        src: src,
        client : client,
        bootstrap: {
            less: './bower_components/bootstrap/less/bootstrap.less',
            css: temp + 'bootstrap.css',
            fonts: './bower_components/bootstrap/fonts/**/*.*',
        },
        fonts: './bower_components/components-font-awesome/fonts/**/*.*',
        html: clientApp + '**/*.html',
        htmltemplates: clientApp + '**/*.html',
        js: [
            clientApp + '**/*.module.js',
            clientApp + '**/*.js'
        ],
        css: client + 'content/style.css',
        temp: temp,
        server: server,
        index: client + 'index.html',
        /**
         * browser sync
         */
        browserReloadDelay: 1000,

        /**
         * Bower and NPM locations
         */
        bower: {
            json: require('./bower.json'),
            directory: './bower_components/',
            ignorePath: '../..'
        },
         /**
         * optimized files
         */
        optimized: {
            app: 'app.js',
            lib: 'lib.js'
        },

         /**
         * template cache
         */
        templateCache: {
            file: 'templates.js',
            options: {
                module: 'app.core',
                standAlone: false,
                root: 'app/'
            }
        },
         /**
         * Node settings
         */
        defaultPort: 7203,
        nodeServer: './src/server/app.js'

    };

    config.getWiredepDefaultOptions = function () {
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath
        };
        return options;
    };

    return config;
};
