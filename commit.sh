#!/bin/sh

# This always comes from cloud build so, so push with force after the only edited asset is saved(ProjectSettings)
git commit $1 -m "Automated file edit" && git push --force origin HEAD


