module program

// <Snippet9>
open System

// Define a provider and two observers.
let provider = LocationTracker()
let reporter1 = LocationReporter "FixedGPS"
reporter1.Subscribe provider
let reporter2 = LocationReporter "MobileGPS"
reporter2.Subscribe provider

provider.TrackLocation { Latitude = 47.6456; Longitude = -122.1312 }
reporter1.Unsubscribe()
provider.TrackLocation { Latitude = 47.6677; Longitude = -122.1199 }
provider.TrackLocation(Nullable())
provider.EndTransmission()
// The example displays output similar to the following:
//      FixedGPS: The current location is 47.6456, -122.1312
//      MobileGPS: The current location is 47.6456, -122.1312
//      MobileGPS: The current location is 47.6677, -122.1199
//      MobileGPS: The location cannot be determined.
//      The Location Tracker has completed transmitting data to MobileGPS.
// </Snippet9>