//
// This custom View is referenced by SwiftUISampleInjectedScene
// to provide the body of a WindowGroup. It's part of the Unity-VisionOS
// target because it lives inside a "SwiftAppSupport" directory (and Unity
// will move it to that target).
//

import Foundation
import SwiftUI
import UnityFramework

struct TestContentView: View {
    var body: some View {
        VStack {
            Text("Bukit Timah Title")
                .bold()
            Text("Bukit Timah Description")
            Button("Reset") {
                CallCSharpCallback("reset bukit timah")
            }
            Button("Swap") {
                CallCSharpCallback("swap cube")
            }
        }
        .onAppear {
            // Call the public function that was defined in SwiftUISamplePlugin
            // inside UnityFramework
            CallCSharpCallback("appeared")
        }
    }
}

#Preview(windowStyle: .automatic) {
    TestContentView()
}

