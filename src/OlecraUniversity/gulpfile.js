﻿/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    sass = require("gulp-sass");

var webroot = "./wwwroot/";

var paths = {
    js: webroot + "js/**/*.js",
    minJs: webroot + "js/**/*.min.js",
    css: webroot + "css/**/*.css",
    minCss: webroot + "css/**/*.min.css",
    concatJsDest: webroot + "js/site.min.js",
    concatCssDest: webroot + "css/site.min.css"
};

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

// Task to minify css generated from sass
gulp.task("min:sass-css", function () {
    return gulp.src('wwwroot/css/sae.css')
        .pipe(concat('wwwroot/css/sae.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("sass", function () {
    //return gulp.src('Styles/sae.scss')  // Tells what file to use for gulp task
    return gulp.src('Styles/**/*.scss')   // Gets all files ending with .scss in Styles folder and children directories
        .pipe(sass())                     // Converts SASS to CSS
        .pipe(gulp.dest('wwwroot/css'));  // Tells where to save file after running task
});

gulp.task("min", ["min:js", "min:css"]);
