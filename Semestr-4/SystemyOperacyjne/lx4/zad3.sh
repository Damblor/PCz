#!/bin/bash

for i in /home/linux/*
do
	echo $i
	sudo chmod ugo+r $i
done
