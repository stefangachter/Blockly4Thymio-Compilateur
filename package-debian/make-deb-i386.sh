#!/bin/bash
rm ./*i386.deb
rm ./blockly4thymio/DEBIAN/control
rm ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
rm ./blockly4thymio/usr/bin/blockly4thymio-compilateur*
cp ./fichiers-i386/control-i386 ./blockly4thymio/DEBIAN/control
cp ./fichiers-i386/asebahttp-i386 ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
cp ./fichiers-i386/Compilateur.1.2-i386.exe ./blockly4thymio/usr/bin/blockly4thymio-compilateur.1.2
dpkg-deb --build blockly4thymio blockly4thymio-1.2-i386.deb