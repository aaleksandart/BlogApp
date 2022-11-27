import { useAuth0 } from '@auth0/auth0-react'
import { useState } from 'react'
import As from '../../assets/images/avatar.png'

const PictureForm = () => {

    const { user, isAuthenticated, getAccessTokenSilently } = useAuth0();
    const defaultPicture = require('../../assets/images/avatar.png')
    const [pictureSrc, setPictureSrc] = useState(defaultPicture);
    const [pictureData, setPictureData] = useState()
    const [pictureUrl, setPictureUrl] = useState(null)

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

        let result;
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
        console.log(await result.json())
        console.log(result)
        // async function getPicture() {
        //     let pictureResult = await fetch('https://localhost:7222/api/Pictures');
        //     console.log(await pictureResult);
        //     console.log(result.result[1])
        //     console.log(await pictureResult.json()[2].FileContents);
        //     let byteReader = new FileReader()
        //     byteReader.readAsBinaryString(await pictureResult.json()[1])
        // }
        // getPicture();
        // setPictureUrl(result.pictureData)
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

                <div className='input-comp'>
                    <label htmlFor='img-upload'>Choose a file(.png or .jpg)</label>
                    <input className='shadow' id='img-upload' name='img-upload' type="file" accept='image/png, image/jpeg' onChange={setPicture} />
                </div>

                <button className='shadow' id='submitPicture'>Submit</button>
            </form>

            {
                // pictureUrl &&
                // <div className='card'>
                //     <div className="i-container">
                //         <img src={pictureUrl} alt="" />
                //     </div>
                // </div>
            }
        </>
    )
}

export default PictureForm