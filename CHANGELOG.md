# Changelog
All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [released]

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
