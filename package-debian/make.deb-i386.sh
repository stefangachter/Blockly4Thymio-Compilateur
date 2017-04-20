#!/bin/bash
rm ./blockly4thymio-i386.deb
rm ./blockly4thymio/DEBIAN/control
rm ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
cp ./control-i386 ./blockly4thymio/DEBIAN/control
cp ./asebahttp-i386 ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
dpkg-deb --build blockly4thymio blockly4thymio-i386