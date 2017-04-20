#!/bin/bash
rm ./blockly4thymio-amd64.deb
rm ./blockly4thymio/DEBIAN/control
rm ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
cp ./control-amd64 ./blockly4thymio/DEBIAN/control
cp ./asebahttp-amd64 ./blockly4thymio/usr/bin/blockly4thymio-asebahttp
dpkg-deb --build blockly4thymio blockly4thymio-amd64