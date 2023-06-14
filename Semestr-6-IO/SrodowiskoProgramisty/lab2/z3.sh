#!/bin/bash
if [ $# -ne 1 ]; then
        echo "Witaj $(whoami)"
else
        echo "Witaj $1"
fi

