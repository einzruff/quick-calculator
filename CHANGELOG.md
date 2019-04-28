# Changelog
All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [released]

## [1.0.8] - 2019-04-28
### Added
- Added quad shape for textboxes
- Added persistence to some settings
- Added fine tuner for constants to testForm
- Added conversion result rounding up

## [1.0.7] - 2019-04-07
### Added
- Added Volume as a conversion type.

### Changed
- Resized rect caret to align with bottom of textbox.

## [1.0.6] - 2019-03-30
### Added
- Select caret shape (Rectangle or Triangle) in settings panel.
- Added Mass as a conversion type.

### Changed
- Garbage collection now happens later, was too frequent.
- Conversion textboxes resized to show Scientific Notation formatted numbers correctly.

## [1.0.5] - 2019-03-24
### Added
- You can now specify negative numbers in the left textbox if you position the caret to the leftmost position.
- You can now change the result textbox background color with a color wheel in the settings panel.

### Changed
- Set initial caret fade speed to a slower speed of 12.
- Moved caret fade checkbox to settings panel.
- Initialized the conversion tab textboxes and made the text size of the units more readable.
- On the conversion tab, both values of the calculation will now update as soon as you change a unit.

## [1.0.4] - 2019-03-19
### Changed
- Apparently, calling CreateCaret multiple times per second creates a lot of GDI handles, and the program was crashing about 20 minutes in if the caret fade was enabled. Upon further digging, I found there is an adjustable 10,000 per program GDI handle limit in Windows and a maximum Windows number of 65,536. In 1.0.4 the program releases the GDI handles during the periodic garbage collection method and seems to solve the issue.

## [1.0.3] - 2019-03-16
### Added
- Fixed memory leak. Program will now reduce its memory footprint every so often.
- Left textbox enter key works again.
- You can now enter a number in the left textbox, then an operator key (add,subtract,multiply,divide), then the right textbox will focused. Once you press enter at that point, focus will go back to the left textbox. You can also repeatedly enter calculations in the left textbox, as originally designed, by typing a number then enter in the left textbox.
- Caret speed adjustment (value of 0-127, initially 40)
- Caret color adjustment (gradient between 2 different colors)
- Settings panel

## [1.0.2] - 2019-03-14
### Added
- Added caret fade to the main textboxes.
- I noticed the caret fade gradually increases the program's memory footprint, fix in future update.
- Forgot to reenable enter key event for left textbox, will fix it on next update.

## [1.0.1] - 2019-03-10
### Changed
- Fixed empty left value result label & added image to README.md.

## [1.0.0] - 2019-02-27
### Added
- Initial commit.

### Removed
- Initial commit.
