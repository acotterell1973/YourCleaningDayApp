(function (global) {

    var paths = {
        // paths serve as alias
        'npm:': '/js/'
    };
    //map tells the System loader where to look for things
    var map = {
        app: 'app', //out application files
        '@angular': 'npm:@angular', //angular2 packages
        'rxjs': 'npm:rxjs' //Rxjx package
    };

    // packages tells the System loader which filename and/or extensions to look for by default (when none are specified)
    var packages = {
        app: {
            main: './main.js',
            defaultExtension: 'js'
        },
        rxjs: {
             defaultExtension: 'js'
        }
    };

    //configure @angular packages
    var ngPackageNames = [
        'core',
        'common',
        'compiler',
        'http',
        'platform-browser',
        'platform-browser-dynamic',
        'upgrade'
    ];

    function packIndex(pkgName) {
        packages['npm:@angular/' + pkgName] = { main: 'index.js', defaultExtension: 'js' };
    }

    function packUmd(pkgName) {
        packages['npm:@angular/' + pkgName] = { main: '/bundles/'+ pkgName +'.umd.js', defaultExtension: 'js' };
    }

    var setPackageConfig = System.packageWithIndex ? packIndex : packUmd;

    // add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
    ngPackageNames.forEach(setPackageConfig);

    var config = {
        paths: paths,
        map: map,
        packages: packages
    }

    // filterSystemConfig - index.html's chance to modify config before we register it.
    if (global.filterSystemConfig) { global.filterSystemConfig(config); }

    System.config(config);

})(this);