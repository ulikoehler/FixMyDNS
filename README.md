# FixMyDNS
Tired of telling people how to manually configure the DNS servers to fix DNS issues on Windows? Just send them FixMyDNS, let them run it.

## How does it work.

This is a C# (.NET 4) program that simply sets the DNS servers for all your network interfaces to [1.1.1.1, CloudFlare's DNS servers](https://www.cloudflare.com/en-us/dns/).

If DNS is actually the core issue of your network problems, they will most certainly be gone after running this program.

![](https://raw.githubusercontent.com/ulikoehler/FixMyDNS/master/Screenshot.PNG)

## How can I use it?

Download FixMyDNS.exe from TechOverflow (my website) [https://techoverflow.net/downloads/FixMyDNS.exe](https://techoverflow.net/downloads/FixMyDNS.exe) and run it.
No configuration or user input needed, just a simple prompt for admin permissions and that's it.

Need to download it somewhere where DNS doesn't work at all? [http://95.216.138.188/FixMyDNS.exe](http://95.216.138.188/FixMyDNS.exe)

The `sha256sum` of the current release 1.0 is `ee9acdcfef87c60e956deed23704632e55b3ba9e07c55fb75a1bde58a927c8fe`.

This repository contains the source code for the program. If you don't trust me on providing some EXE that you run with admin rights, just build it yourself - the source code is pretty simple.

Note that the configuration will not survive a reboot. This is intentional since we don't want to permanently change any configuration.

Don't know what DNS is but your internet doesn't work? Maybe this is the solution for you, but probably not. Usually FixMyDNS won't break anything, so it might be worth a try (on your own responsibility of course)...

## About

This was built by [Uli Köhler](https://techoverflow.net/) who was tired of wasting time telling people how to fix their DNS config.
Licensed under Apache License v2.0
