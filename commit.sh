#!/bin/sh

#Adds only the incr_version file, commits it to git and pushes it with force
git commit $1 -m "Increase version number" && git push origin HEAD
