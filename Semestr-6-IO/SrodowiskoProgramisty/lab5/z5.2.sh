#!/bin/bash

sed -n '/^[a-zA-Z_]\{1,8\}\.[a-zA-Z]\{1,3\}$/p' $1
