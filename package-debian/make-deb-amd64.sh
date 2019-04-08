#!/bin/bash
rm ./*amd64.deb
rm ./blockly4thymio/DEBIAN/control
rm ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
rm ./blockly4thymio/usr/bin/blockly4thymio-compilateur*
cp ./fichiers-amd64/control-amd64 ./blockly4thymio/DEBIAN/control
cp ./fichiers-amd64/asebahttp-amd64 ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
cp ./fichiers-amd64/Compilateur.1.2-amd64.exe ./blockly4thymio/usr/bin/blockly4thymio-compilateur.1.2
dpkg-deb --build blockly4thymio blockly4thymio-1.2-amd64.deb