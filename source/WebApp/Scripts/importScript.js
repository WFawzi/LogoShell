var scriptFileContent = "";
var fileType = "";

function readScript(evt) {
    //Retrieve the first (and only!) File from the FileList object
    var f = evt.target.files[0];

    fileType = f.type;
    if (validateTextFile()) {
        EnableImportScript();

        if (f) {
            var r = new FileReader();
            r.onload = function (e) {
                var contents = e.target.result;
                scriptFileContent = contents;
            }
            r.readAsText(f);
        } else {
            alert("Failed to load file");
        }
    }
}

document.getElementById('fileinput').addEventListener('change', readScript, false);


function ImportScript() {
    var userScript = document.getElementById("codeEditor");
    userScript.value = scriptFileContent;
}

function DisableImportScript() {
    var importScriptButton = document.getElementById("buttonImportScript");
    importScriptButton.disabled = true;
}

function EnableImportScript() {
    var importScriptButton = document.getElementById("buttonImportScript");
    importScriptButton.disabled = false;
}


//Validation STARTS HERE
function validateTextFile() {
    //txt file
    if (fileType !== "text/plain") {
        alert("Please select a text file");
        return false;
    }
    else {
        return true;
    }
}

function validateTurtleInstructions() {
    //Imported file has commands like:
    //$turtle.MoveForward(100);
    //$turtle.Turn(90);
}
//Validation ENDS HERE