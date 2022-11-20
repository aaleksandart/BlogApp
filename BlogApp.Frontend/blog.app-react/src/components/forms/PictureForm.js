import { useAuth0 } from '@auth0/auth0-react'

const PictureForm = () => {

    const { user, isAuthenticated } = useAuth0();
    return (
        <>
            <form >
                <div className='input-comp'>
                    <label htmlFor='uploaded-by'>Uploaded by</label>
                    {
                        isAuthenticated &&
                        <input id='uploaded-by' className='shadow' value={user.name} readOnly />
                    }
                </div>

                <div className='input-comp'>
                    <label htmlFor='img-upload'>Choose a file(.png or .jpg)</label>
                    <input className='shadow' typeof='' id='img-upload' name='img-upload' type="file" accept='image/png, image/jpeg' />
                </div>

                <button className='shadow' id='submitPicture'>Submit</button>
            </form>
        </>
    )
}

export default PictureForm