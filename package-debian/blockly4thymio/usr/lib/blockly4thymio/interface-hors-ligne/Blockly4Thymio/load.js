/**
 * @fileoverview Load and save functions
 * @author emmanuel.fort@gmail.com
 */
'use strict';



function  handleSaveButtonClick() {
  var xml = Blockly.Xml.workspaceToDom(Blockly.getMainWorkspace());  
  xml = Blockly.Xml.domToText(xml);
  xml = encodeURI(xml);
  xml = xml.replace( /#/g, "%23" );
  var link = document.getElementById('saveLink');
  link.download = "programme.b4t";
  //link.href = "data:application/octet-stream," + xml;
  link.href = "data:application/b4t," + xml;
  link.click();  
}


function handleLoadButtonClick(evt) {
	var files = evt.target.files; // FileList object
	var file = files[0];
	var fileReader = new FileReader();
	fileReader.onload = (function(theFile) {
      return function(e) {
        //alert(fileReader.result);
		var xml = Blockly.Xml.textToDom(fileReader.result);
		Blockly.Xml.domToWorkspace(Blockly.getMainWorkspace(), xml);
      };
    })(file);
	fileReader.readAsText(file);
}


    