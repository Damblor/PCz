#!/bin/bash

sed -n '/[0-9]\+.[0-9]\+e\(+\|-\)[0-9]\+/p' $1
