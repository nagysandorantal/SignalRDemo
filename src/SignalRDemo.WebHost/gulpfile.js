/// <binding AfterBuild='min, copy' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify');

var paths = {
    webroot: "./wwwroot/"
};

paths.bootstrapCss =    "./bower_components/bootstrap/dist/css/bootstrap.css";
paths.sbAdminCss =      "./bower_components/startbootstrap-sb-admin-2/dist/css/sb-admin-2.css";
paths.fontAwsomeCss =   "./bower_components/font-awesome/css/font-awesome.css";
paths.morrisCss =       "./bower_components/morrisjs/morris.css";
paths.siteCss = paths.webroot + "css/site.css";

paths.jqueryJs =    "./bower_components/jquery/dist/jquery.js";
paths.raphaelJs =   "./bower_components/raphael/raphael.js";
paths.morrisJs =    "./bower_components/morrisjs/morris.js";
paths.signalRJs =   "./bower_components/signalr/jquery.signalr.js";
paths.bootstrapJs = "./bower_components/bootstrap/js/*.js";
paths.chatJs =      "./scripts/chat.js";

paths.fonts = "./bower_components/font-awesome/fonts/*";

paths.jsDest = paths.webroot + "js";
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "fonts";


gulp.task("min:js", function () {
    gulp.src([
            paths.raphaelJs,
            paths.morrisJs,
            paths.bootstrapJs]
        )
    .pipe(concat(paths.jsDest + "/min/site.min.js"))
    .pipe(uglify())
    .pipe(gulp.dest("."));
});

gulp.task('min:css', function () {
    gulp.src([paths.bootstrapCss, paths.morrisCss, paths.sbAdminCss, paths.fontAwsomeCss, paths.siteCss])
    .pipe(concat(paths.cssDest + "/min/site.min.css"))
    .pipe(cssmin())
    .pipe(gulp.dest("."));
});

 
gulp.task('copy:js', function () {
    gulp.src([
            paths.jqueryJs,
            paths.signalRJs,
            paths.raphaelJs,
            paths.morrisJs,
            paths.bootstrapJs,
            paths.chatJs]
        )
    .pipe(gulp.dest(paths.jsDest));
});

gulp.task('copy:css', function () {
    gulp.src([paths.bootstrapCss, paths.morrisCss, paths.sbAdminCss, paths.fontAwsomeCss])
    .pipe(gulp.dest(paths.cssDest));
});

gulp.task('copy:fonts', function () {
    gulp.src([paths.fonts])
    .pipe(gulp.dest(paths.fontDest));
});


gulp.task("min", ["min:js", "min:css"]);
gulp.task("copy", ["copy:js", "copy:css", "copy:fonts"]);
