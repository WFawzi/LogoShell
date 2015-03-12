//General notes for voice commands:
//1. Voice comamnds will work only in browsers supporting voice detection, like Chrome. But won't work in IE for example.
//2. If you have 2 tabs with voice detection running in Chrome, Chrome will get confused and non of the tabs will work. Keep only one 


//Bug: When the browser stops listening (when it promts to allow/ deny microphone), the colour of the whole drawing changes to the current colour of the brush
function VoiceCommand() {
    if (annyang) {

        //VIP NOTE: 
        //If we add the addMove and addTurn functions after the commands, 
        //the browser will not add the 'move forward *step' and the 'turn *angle' commands
        //When debugging, you'll notice "Commands successfully loaded: 6", instaed of "Commands successfully loaded: 8"
        //The reason for this behavior is unknown

        var addMove = function (step) {

            if (isNaN(step)) {              //If the user says anything but a number after "Move forward", eg: "Move forward banana"

                $.getScript("scripts/speakClient.js", function () {

                    speak("Please say a number after move forward");
                });
            }
            else {
                var userScript = document.getElementById("codeEditor");
                userScript.value = userScript.value + '\n$turtle.MoveForward(' + step + ')'
            }
        }

        var addTurn = function (angle) {
            if (isNaN(angle)) {
                $.getScript("scripts/speakClient.js", function () {

                    speak("Please say a number after turn");
                });
            }
            else {
                var userScript = document.getElementById("codeEditor");
                userScript.value = userScript.value + '\n$turtle.Turn(' + angle + ')'
            }
        }

        var commands = {
            'draw': function () {
                SendScript();
            },
            'clear': function () {
                ClearCanvas();
            },
            'brush black': function () {
                brushColour = 'black';  //Changes the brush colour to black

                //Changes the colour dropdwon to black (just to show the user the current colour of the brush)
                var colourSelector = document.getElementById("selectColour");
                colourSelector.value = 'black';
            },
            'brush blue': function () {
                brushColour = 'blue';

                var colourSelector = document.getElementById("selectColour");
                colourSelector.value = 'blue';
            },
            'brush green': function () {
                brushColour = 'green';

                var colourSelector = document.getElementById("selectColour");
                colourSelector.value = 'green';
            },
            'clear script': function () {
                var userScript = document.getElementById("codeEditor");
                userScript.value = '';
            },
            'move forward *step': addMove,
            'turn *angle': addTurn
        };

        annyang.debug();

        // Initialize annyang with our commands
        annyang.init(commands);

        // Start listening. You can call this here, or attach this call to an event, button, etc.
        annyang.start();
    }
}
