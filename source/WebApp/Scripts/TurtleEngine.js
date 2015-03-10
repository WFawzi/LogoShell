var turtleState = {
    x: 0,
    y: 0,
    direction: 0,
    path: [],
    reset: function () {
        path = [];
        x = 0;
        y = 0;
        direction = 0;
    }
};


var brushColour = 'black';


$(document).ready(function () {

    var resizeCanvas = function () {
        var c = document.getElementById("logoCanvas");
        var ctx = c.getContext("2d");

        c.width = $('#canvasWrapper').width();
        c.height = window.innerHeight * 0.6;

        Draw(turtleState.path);
    }

    $(window).resize(resizeCanvas);
    resizeCanvas();

    var colourSelector = document.getElementById("selectColour");
    brushColour = colourSelector.value;
});

function SendScript() {

    //Generally, the intlliesnece of JavaScript is not complete, so debug in the browser, to get the full intlliesnece

    //var userScript = document.getElementById("codeEditor").value; // Here we are getting the element from teh DOM, we can also use JQuery to get the element: var userScript = $('#codeEditor').value
    var userScript = $('#codeEditor').val(); //the JS can find the element with ID: codeEditor, because both the script and the element with ID: codeEditor or loaded on the same page

    var formData = {
        userScript: userScript, //pass userScript to the UserScript of the DrawModel - the MVC model binder is not case sensitive, so "userScript:" here maps to UserScript of the DrawModel
        direction: turtleState.direction,
        x: turtleState.x,
        y: turtleState.y
    }; //always use ";" in JS

    $.ajax({
        url: "/Turtle/Draw",            //Remember from RouteConfig.cs, url: "{controller}/{action}
        type: "POST",                   //We are POSTing (writing to server) to the controller at the URL "/Turtle/Draw"
        data: formData,
        success: function (data, textStatus, jqXHR) {
            //data - response from server
            Draw(data.path);
            turtleState.path = turtleState.path.concat(data.path);
            SaveTurtleState(data.x, data.y, data.direction);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
};


function Draw(path) {

    if (!path || path.length === 0) {
        return;
    }

    var c = document.getElementById("logoCanvas");
    //var c = $('#logoCanvas'); //<-- Not working with the below properties since the DOM and JQuery have different properties, "getContext" foe example is not part of the JQuery properties

    var canvHeight = c.height;
    var canvWidth = c.width;

    var ctx = c.getContext("2d");
    ctx.lineWidth = 2;

    //moveTo, is where you start your drawing - the initial position of the pencil
    //lineTo: is the actual drawing
    ctx.beginPath();    //Without this, when the brush colour is changed, all the draw colour will change, instead of only the new lines you are drawing
    ExecuteChangeBrushColor();
    ctx.moveTo(((canvWidth / 2) + path[0].x), ((canvHeight / 2) - path[0].y));

    for (var i = 1; i < path.length; i++) {
        var point = path[i];
        var canvasX = (canvWidth / 2) + point.x;
        var canvasY = (canvHeight / 2) - point.y;

        ctx.lineTo(canvasX, canvasY);
    };

    ctx.stroke();
};

function SaveTurtleState(x, y, direction) {

    turtleState.x = x;
    turtleState.y = y;
    turtleState.direction = direction;

};


function ClearCanvas() {
    var canvas = document.getElementById("logoCanvas");
    var ctx = canvas.getContext("2d");

    //This is a hack. clearrect() following by stroke() seems to redraw all the lines we drew in the past.
    //setting and restoring width seems to destructively (yay!) clear the canvas.
    canvas.width = canvas.width + 1;
    canvas.width = canvas.width - 1;

    turtleState.reset();
}


function ChangeBrushColor() {
    var colourSelector = document.getElementById("selectColour");
    var currentColour = colourSelector.value;

    switch (currentColour) {
        case 'black':
            brushColour = 'black';
            break;
        case 'blue':
            brushColour = 'blue';
            break;
        case 'green':
            brushColour = 'green';
            break;
        default:
            brushColour = 'black';
    }
}

function ExecuteChangeBrushColor() {
    var c = document.getElementById("logoCanvas");
    var ctx = c.getContext("2d");

    switch (brushColour) {
        case 'black':
            ctx.strokeStyle = 'rgb(41, 36, 33)'; //you can use RGB or HEX for the colour
            break;
        case 'blue':
            ctx.strokeStyle = 'rgb(0, 0, 255)';
            break;
        case 'green':
            ctx.strokeStyle = 'rgb(0, 255, 0)';
            break;
        default:
            ctx.strokeStyle = 'rgb(41, 36, 33)';
    }
}


/*
//Voice Recognition STARTS HERE
//src="//cdnjs.cloudflare.com/ajax/libs/annyang/1.4.0/annyang.min.js"
src = "//Scripts/annyang.min.js"
if (annyang) {
    // Let's define our first command. First the text we expect, and then the function it should call
    var commands = {
        'show tps report': function () {
            alert("I am an alert box!");
        }
    };

    // Add our commands to annyang
    annyang.addCommands(commands);

    // Start listening. You can call this here, or attach this call to an event, button, etc.
    annyang.start();
}
//Voice Recognition ENDS HERE
*/