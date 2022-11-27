import { useAuth0 } from '@auth0/auth0-react'
import { useState } from 'react'

const PictureForm = () => {

    const { user, isAuthenticated, getAccessTokenSilently } = useAuth0();
    const defaultPicture = require('../../assets/images/avatar.png')
    const [pictureSrc, setPictureSrc] = useState(defaultPicture);
    const [pictureData, setPictureData] = useState();

    const [formErrors, setFormErrors] = useState({ pictureError: '' });

    const setPicture = (e) => {
        let fileReader = new FileReader()
        fileReader.readAsDataURL(e.target.files[0])

        fileReader.onload = x => {
            setPictureSrc(x.target.result)
        }
        setPictureData(e.target.files[0])
    }

    const submitPicture = async (e) => {
        e.preventDefault()

        validateFormError();
        let result;
        const connErrors = document.getElementById('connPictureError');
        const saveSuccess = document.getElementById('connPictureSuccess');
        const aToken = await getAccessTokenSilently({ audience: process.env.REACT_APP_AUTH0_AUDIENCE });

        const formData = new FormData()
        formData.append("file", pictureData)

        try {
            result = await fetch('https://localhost:7222/api/Pictures', {
                method: 'post',
                headers: {
                    'authorization': `bearer ${aToken}`
                },
                body: (formData)
            });
        } catch (e) {
            console.log(e);
        }
        if (result === undefined) {
            connErrors.classList.add('d-block')
        } else {
            if (result.status === 200) {
                connErrors.classList.add('d-none');
                saveSuccess.classList.add('d-block');
                setTimeout(() => {
                    window.location.reload()
                }, 4000);
            } else if (result.status === 400) {
                validateFormError();
            } else {
                connErrors.classList.add('d-block');
            }
        }
    }

    function validateFormError() {
        if (pictureData === undefined) {
            setFormErrors({ pictureError: "You need a file." });
        } else {
            setFormErrors({ pictureError: "" });
        }
    }

    return (
        <>
            <div className='card shadow'>
                <div className='i-container'>
                    <img src={pictureSrc} alt='' />
                </div>
            </div>
            <form onSubmit={submitPicture}>
                <div className='input-comp'>
                    <label htmlFor='uploaded-by'>Uploaded by</label>
                    {
                        isAuthenticated &&
                        <input id='uploaded-by' className='shadow' value={user.name} readOnly />
                    }
                </div>

                <div className='input-comp picture-error'>
                    <label htmlFor='img-upload'>Choose a file(.png or .jpg)</label>
                    <input className='shadow' id='img-upload' name='img-upload' type="file" accept='image/png, image/jpeg' onChange={setPicture} />
                    {formErrors.pictureError && <small id='picture-error' className="text-danger ms-1">{formErrors.pictureError}</small>}
                </div>

                <button className='shadow' id='submitPicture'>Submit</button>
                <div id='connPictureError' className='connError shadow'>
                    <span>Database connection error. Save not completed.</span>
                </div>
                <div id='connPictureSuccess' className='saveSuccess shadow'>
                    <span>Your post was succesfully saved.</span>
                </div>
            </form>
        </>
    )
}

export default PictureForm