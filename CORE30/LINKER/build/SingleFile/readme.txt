This CoreRun host has been customized as follows:
subsystem is set to windows to avoid showing the console
manifest has been embedded to enable dpi-aware


These were built from https://github.com/ericstj/coreclr/commit/6c6996bffb5d3ff87f6078551e917f233250ca19

The targets here will intercept a publish to point it at a different directory,
we then run the bundler on that directory to embed the contents in a host,
and write that host to the real publish directory.