/// <binding ProjectOpened='default' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    gp_clean = require('gulp-clean'),
    gp_concat = require('gulp-concat'),
    gp_sourcemaps = require('gulp-sourcemaps'),
    gp_typescript = require('gulp-typescript'),
    gp_uglify = require('gulp-uglify');

// Define Paths
var sourcePaths = {
    app: ['Scripts/app/main.ts', 'Scripts/app/**/*.ts'],
    js: [
        'Scripts/js/**/*.js',
        'node_modules/core-js/client/shim.min.js',
        'node_modules/zone.js/dist/zone.js',
        'node_modules/reflect-metadata/Reflect.js',
        'node_modules/systemjs/dist/system.src.js',
        'node_modules/typescript/lib/typescript.js'
    ],
    js_angular: ['node_modules/@angular/**'],
    js_rxjs: ['node_modules/rxjs/**']
};

var destinationPaths = {
    app: 'wwwroot/app/',
    js: 'wwwroot/js/',
    js_angular: 'wwwroot/js/@angular',
    js_rxjs: 'wwwroot/js/rxjs/'
};

// Compile, minify and create sourcemaps all TypeScript files
// and place them to wwwroot/app, together with their js.map files.
gulp.task('app', ['app_clean'], function () {
    return gulp.src(sourcePaths.app)
        .pipe(gp_sourcemaps.init())
        .pipe(gp_typescript(require('./tsconfig.json').compilerOptions))
        .pipe(gp_uglify({ mangle: false }))
        .pipe(gp_sourcemaps.write('/'))
        .pipe(gulp.dest(destinationPaths.app));
});

// delete wwwroot/app contents
gulp.task('app_clean', function () {
    return gulp.src(destinationPaths.app + '*', { read: false })
        .pipe(gp_clean({ force: true }));
});

// copy al JS files from external libraries to wwwroot/js
gulp.task('js', function () {
    gulp.src(sourcePaths.js_angular)
        .pipe(gulp.dest(destinationPaths.js_angular));

    gulp.src(sourcePaths.js_rxjs)
        .pipe(gulp.dest(destinationPaths.js_rxjs));

    return gulp.src(sourcePaths.js)
        // .pipe(gp_uglify({ mangle: false }))
        // .pipe(gp_concat('app.min.js'))
        .pipe(gulp.dest(destinationPaths.js));
});

// delete wwwroot/js contents
gulp.task('js_clean', function () {
    return gulp.src(destinationPaths.js + "*", { read: false })
        .pipe(gp_clean({ force: true }));
});

gulp.task('watch', function () {
    gulp.watch([sourcePaths.app, sourcePaths.js], ['app', 'js']);
});

// Global cleanup task
gulp.task('cleanup', ['app_clean', 'js_clean']);

//
gulp.task('default', ['app', 'js', 'watch']);