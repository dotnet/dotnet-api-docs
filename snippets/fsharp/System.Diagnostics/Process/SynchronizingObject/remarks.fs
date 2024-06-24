module remarks

let x (process1: System.Diagnostics.Process) this =
    // <Snippet2>
    process1.StartInfo.Domain <- "";
    process1.StartInfo.LoadUserProfile <- false;
    process1.StartInfo.Password <- null;
    process1.StartInfo.StandardErrorEncoding <- null;
    process1.StartInfo.StandardOutputEncoding <- null;
    process1.StartInfo.UserName <- "";
    process1.SynchronizingObject <- this;
    // </Snippet2>