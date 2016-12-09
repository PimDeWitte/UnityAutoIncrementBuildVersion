#!/bin/sh


if [ ! -f deploy ]; then
    echo "UnityAutoIncrementBuildVersion: Deploy File not found! See the documentation on how to create one. Commiting the file back to Unity will likely fail."
fi

# Add the deploy key, and add github to known hosts so we can push
ssh-keyscan -H github.com >> ~/.ssh/known_hosts
ssh-add deploy
# This always comes from cloud build so, so push with force after the only edited asset is saved(ProjectSettings)
git commit $1 -m "Automated file edit" && git push --force origin HEAD


