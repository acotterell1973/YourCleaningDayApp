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
    app: ['Scripts/app/main.js', 'Scripts/**/*.ts', 'Scripts/js/**/*.js']
    js: 'wwwroot/js/'
};

var destPaths = {
    app: 'wwwroot/app/',
    js: 'wwwroot/js/'
};

// Compile, minify and create sourcemaps all TypeScript files
// and place them to wwwroot/app, together with their js.map files.

gulp.task('app', function() {
    return gulp.src(sourcePaths.app)
        .pipe(gp_sourcemaps.init())
        .pipe(gp_typescript(require('./tsconfig.json').compilerOptions))
        .pipe(gp_uglify({ mangle: false }))
        .pipe(gp_sourcemaps.write('/'))
        .pipe(gulp.dest(destPaths.app));
});

//Delete wwwroot/app contents
gulp.task('app_clean', function() {
    return gulp.src(destPaths.app + '*', { read: false })
        .pipe(gp_clean({ force: true }));
});

//

gulp.task('default', function() {
    // place code for your default task here
});