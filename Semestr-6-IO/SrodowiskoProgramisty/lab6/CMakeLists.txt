cmake_minimum_required(VERSION 2.6)
project(trees)

set(SRC drzewo.cpp gruszka.cpp swierk.cpp wierzba.cpp main.cpp)
set(CMAKE_VERBOSE_MAKEFILE ON)

if(CMAKE_COMPILER_IS_GNUCXX)
	add_definitions(-Wall -pedantic)
endif()

if(NOT CMAKE_BUILD_TYPE)
	set(CMAKE_BUILD_TYPE "Relase")
endif()

add_executable(main ${SRC})

add_custom_target(clean-all
	rm -rfv CMakeCache.txt Makefile cmake_install.cmake CMakeFiles/
)
