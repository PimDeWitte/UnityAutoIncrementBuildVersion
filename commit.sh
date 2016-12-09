#!/bin/sh
# Add the deploy key

if [ ! -f deploy ]; then
    echo "UnityAutoIncrementBuildVersion: Deploy File not found! See the documentation on how to create one. Commiting the file back to Unity will likely fail."
fi

ssh-add deploy
# This always comes from cloud build so, so push with force after the only edited asset is saved(ProjectSettings)
git commit $1 -m "Automated file edit" && git push --force origin HEAD


