#!/bin/bash

echo podaj scierzke
read pat

if [ -d $pat ]; then
	ls -la $pat
fi
