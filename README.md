# Cognition.ModulePacker
Simple .NET Core 2 command line tool to pack music modules (e.g. ProTracker, FastTracker) into JavaScript for easy replaying

### What is this thing?
It's a quick command line tool which takes the filename of a music module as a parameter, then base64 encodes and wraps it inside a JavaScript file.

In the future it could do something more clever but this is all I needed for the time being.

### Seems a little crazy!? Why do this at all?
**Why not eh!** Actually, I'm trying to code an old skool 2D demo thing in the [Cognition](https://github.com/rarelyprolific/Cognition) repo and I am using [Firehawk's JavaScript web audio module replayer](https://github.com/jhalme/webaudio-mod-player) for the music.

By default, Firehawk's **player.js** script enables you to read a module file via AJAX and play it. Personally, I wanted to embed the module data in my JavaScript and just have the replayer code use it. This is the reason for this tool's existence.

**Still seems bats!%t crazy to me!** *It probably is! :)* But I wanted to remove the need to perform a secondary AJAX load when loading a demo to get the music playing. This means the music can be "single filed" with the demo code and load as a single entity. Additionally, it gets around any potential hosting issues and MIME types if there are any problems serving **mod** or **xm** files from web directories (because they are all just **js** files now).

### Current issues or unhandled situations (this is a quick tool, I may fix these.. one day :))
 * The auto-generated JavaScript module variable relies on your module filename being compatible as a JavaScript variable name. *(If not, you'll need to tweak the name manually in the output
 JS file.. Yes, I know this is rubbish and I will fix it.)*
 * No error checking at all yet!

### Possible future enhancements (if I have the need, time or motivation to do them)
 * Allow an output filename to be specified as a command line parameter.
 * Add ability to unpack modules back into their original binary module files.
 * Add feature to verify module structure or show module information (patterns, sample data. etc.)
 * Add either full module compression or just compress the samples in a module.
 * Maybe create a pure PowerShell version of this tool so it can be used without a reliance on .NET Core? *(Obviously, this doesn't scale if it needs to become more clever but it's technically possible now.)*
