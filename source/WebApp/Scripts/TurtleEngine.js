$(document).ready(function () {
    /*
    var c = document.getElementById("logoCanvas");
    var ctx = c.getContext("2d");
    ctx.lineWidth = 2;
    ctx.moveTo(0, 0);
    ctx.lineTo(50, 150);
    ctx.stroke();
    */
});


function SendScript() {
    
    //Generally, the intlliesnece of JavaScript is not complete, so debug in the browser, to get the full intlliesnece

    //var userScript = document.getElementById("codeEditor").value; // Here we are getting the element from teh DOM, we can also use JQuery to get the element: var userScript = $('#codeEditor').value
    var userScript = $('#codeEditor').val(); //the JS can find the element with ID: codeEditor, because both the script and the element with ID: codeEditor or loaded on the same page

    var formData = {
        userScript: userScript, //pass userScript to the UserScript of the DrawModel - the MVC model binder is not case sensitive, so "userScript:" here maps to UserScript of the DrawModel
        direction: 0,
        x: 0,
        y: 0
    }; //always use ";" in JS
 


    $.ajax({
        url: "/Turtle/Draw",            //Remember from RouteConfig.cs, url: "{controller}/{action}
        type: "POST",                   //We are POSTing (writing to server) to the controller at the URL "/Turtle/Draw"
        data : formData,
        success: function(data, textStatus, jqXHR)
        {
            //data - response from server
            debugger;
            Draw();
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
 
        }
    });
}


function Draw()
{
    var c = document.getElementById("logoCanvas");
    var ctx = c.getContext("2d");
    ctx.lineWidth = 2;
    ctx.moveTo(0, 0);
    ctx.lineTo(50, 150);
    ctx.stroke();
}