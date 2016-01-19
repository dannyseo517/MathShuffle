var track1 : AudioClip;
var track2 : AudioClip;
GetComponent.<AudioSource>().clip = track1;

/* Initial volume of track 1 */
var audio1Volume : float = .615;
/* Initial volume of track 2 */
var audio2Volume : float = 0.0;
/* Specifies when track 2 has started to play */
var track2Playing : boolean = false;

/*
Allows the audio game objects to play music through scene changes.
Normally the object would be destroyed on each scene change.
*/
function Awake() {
	DontDestroyOnLoad(this);
	if (FindObjectsOfType(GetType()).Length > 1)
	{
		Destroy(GameObject.Find("BackgroundMusic"));
	}
}
/*
Fades out the first track then plays the second track once the
first track reaches a specific volume.
*/
function Update() {
	fadeOut();

	if (audio1Volume <= 0.1) {
		if(track2Playing == false)
		{
			track2Playing = true;
			GetComponent.<AudioSource>().clip = track2;
			GetComponent.<AudioSource>().Play();
			GetComponent.<AudioSource>().loop = true;
		}
		fadeIn();
	}
}
/*
Increments the volume of track 2 each time it is called.
*/
function fadeIn() {
	if (audio2Volume < .615) {
		audio2Volume += .5 * Time.deltaTime;
		GetComponent.<AudioSource>().volume = audio2Volume;
	}
}

/*
Decrements the volume of track 1 each time it is called.
*/
function fadeOut() {
	if(audio1Volume > 0.1)
	{
		audio1Volume -= .7 * Time.deltaTime;
		GetComponent.<AudioSource>().volume = audio1Volume;
	}
}