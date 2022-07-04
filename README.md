# Cdsi Date Math

## Why?

In the CDSi Logic Spec supporting data, durations are 
unitized numbers expressed as text strings such as "1 week".

Arithmetic on these durations looks like "1 year - 3 days".

This library parses those strings into Interval objects and 
also provides operators on those objects as well as .NET DateTime
objects and integers.