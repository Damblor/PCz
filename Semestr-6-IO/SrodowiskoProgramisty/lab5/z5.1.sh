#!/bin/bash

sed 's/^[a-zA-Z0-9._+-]\+@[a-zA-Z0-9.-]\+\.[a-zA-Z]\+$/nobody@example.com/' $1
