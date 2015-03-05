$(document).ready(function () {

    var c = document.getElementById("logoCanvas");
    var ctx = c.getContext("2d");
    ctx.lineWidth = 2;
    ctx.moveTo(0, 0);
    ctx.lineTo(50, 150);
    ctx.stroke();



    //Why the below does not work?
    /*$("logoCanvas").drawArc({
        draggable: true,
        fillStyle: "green",
        x: 100, y: 100,
        radius: 50
    });
    */
});