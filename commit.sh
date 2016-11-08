#!/bin/sh

#Adds only the incr_version file, commits it to git and pushes it with force
git add $1 && git commit -m "Increase version number" && git push --force origin HEAD
