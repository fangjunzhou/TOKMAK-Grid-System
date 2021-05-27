# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1.1] - 2021-5-28
### Changed
- SquareGridGenerator use DestroyImmediate instead of Destroy for Editor destroy support
- Added GridEventHandler into GridGenerator
- Added EditorInitialize for editor scripts to initialize the generator

## [0.1.0] - 2021-5-18
### Added
- Use acceleration table to accelerate pathfinding. Decrease the average pathfinding time from 0.001 seconds to 2*10^-5 seconds

## [0.0.7] - 2021-5-15
### Changed
- IGridGenerator now can make change to the global offset in the IGridSystem

## [0.0.6] - 2021-5-14
### Changed
- Now support multiple GridGenerator and GridSystem can merge different generator and system dynamically
- Each GridGenerator has a global offset to shift the local GridCooridnate to a global coordinate
- Now support pathfinding across different GridSystem if they are merged

## [0.0.5] - 2021-5-12
### Changed
- User can choose which direction to generate in the TestGridGenerator MonoBehavior.
- Fixed the error that the edge between current Vertex and bottom right Vertex cannot be removed.

## [0.0.4] - 2021-05-12
### Added
- Add GridDataIO system to store and read data in a .griddat file
- Add an overload of GenerateMap method in IGridGenerator. Now can generate map from .griddata file
- Add an ISerializable field to the GridDataContainer. All the data in the vertex that need to be saved and loaded in .griddat file should be stored in this specific field

### Changed
- Now all vertices can only store data inherited from GridDataContainer class. This is because ISerializable field is needed for Vertex serialization

## [0.0.3] - 2021-05-11
### Added
- Add Assembly Definition files to accelerate build speed

## [0.0.2] - 2021-05-10
### Changed
- Changed the README.md

### Removed
- Removed the dependency in the package.json. Will add in the future if the custom registry has been setup

## [0.0.1] - 2021-05-10
### Added
- The full Grid System package
- Grid System Core system
- Square Grid System implementation
- Functional A star pathfinding algorithm for Square Grid System
- Square Grid System sample code


[Unreleased]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#upm-gridsystem...HEAD
[0.1.0]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.1.0
[0.0.7]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.7
[0.0.6]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.6
[0.0.5]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.5
[0.0.4]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.4
[0.0.3]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.3
[0.0.2]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.2
[0.0.1]: http://anw.noip.cn:8010/Fangjun_Zhou/gridsystem.git#gridsystem-0.0.1