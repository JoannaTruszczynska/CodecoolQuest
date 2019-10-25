# Codecool Quest

This is a simple tile-based RPG game.

## Installing MonoGame

MonoGame is a framework for simple C# games. Before opening the project, you have to install the newest version of MonoGame. You can find it here:
http://community.monogame.net/t/monogame-3-7-1-release/11173

## Opening the project

Open the project in Visual Studio. This is a .NET project.

## Architecture

The project is meant to teach the concept of **layer separation**. All of the game logic (that is, player movement, game rules, and so on), is in the `logic` package, completely independent of user interface code. In principle, you could implement a completely different interface (terminal, web, Virtual Reality...) for the same logic code.

## Product Backlog

[Codecool Quest Product Backlog](https://docs.google.com/spreadsheets/d/1CvVh2s6obWEh4eQxu8w4f3jBLhz208bG-1FybWGc1sA/edit#gid=0)

## Graphics

The tiles used in the game are from [1-Bit Pack by Kenney](https://kenney.nl/assets/bit-pack), shared on [CC0 1.0 Universal license](https://creativecommons.org/publicdomain/zero/1.0/).

![tiles](src/main/resources/tiles.png)
