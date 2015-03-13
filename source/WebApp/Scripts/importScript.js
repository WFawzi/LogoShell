var scriptFileContent = "";

function readScript(evt) {
    //Retrieve the first (and only!) File from the FileList object
    var f = evt.target.files[0];

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

document.getElementById('fileinput').addEventListener('change', readScript, false);


function ImportScript()
{
    var userScript = document.getElementById("codeEditor");
    userScript.value = scriptFileContent;
}
