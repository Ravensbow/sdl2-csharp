using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace csSDL2
{
    class CORE
    {
        public bool bRunning = true;
        public IntPtr win;
        public IntPtr ren;
        SDL.SDL_Event systemEvent;
        


        public CORE()
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO);
            win = SDL.SDL_CreateWindow("SDL2 Sharp", 50, 50, 1280, 720, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            ren = SDL.SDL_CreateRenderer(win, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

            SDL_mixer.Mix_OpenAudio(
            SDL_mixer.MIX_DEFAULT_FREQUENCY,SDL_mixer.MIX_DEFAULT_FORMAT,2,128);
        }

        public void Events()
        {
            
            while (SDL.SDL_PollEvent(out systemEvent) != 0)
            {
              
                //This is an SDL2 escape event  
                if (systemEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    bRunning = false;
                    
                }
                else if (systemEvent.key.keysym.sym == SDL.SDL_Keycode.SDLK_0)
                {
                   
                }
            }
           
        }

        public void Present()
        {
            SDL.SDL_RenderPresent(ren);
        }

        public void Clear()
        {
            SDL.SDL_RenderClear(ren);
        }

        public IntPtr LoadTexture(string filepath)
        {
            return SDL_image.IMG_LoadTexture(ren, filepath);
        }

        public void DrawSprite(IntPtr myTexture, SDL.SDL_Rect sourceRect, SDL.SDL_Rect destinationRect)
        {
            SDL.SDL_RenderCopy(ren, myTexture, ref sourceRect, ref destinationRect);
        }
        public void DrawSpriteEx(IntPtr myTexture, SDL.SDL_Rect sourceRect, SDL.SDL_Rect destinationRect,double kont,double w,double h)
        {

            
                SDL.SDL_Point no;
                no.x = (int)(w / 2);
                no.y = (int)(h / 2);
                SDL.SDL_RenderCopyEx(ren, myTexture, ref sourceRect, ref destinationRect, kont, ref no, SDL.SDL_RendererFlip.SDL_FLIP_NONE);
            
        }

        public IntPtr LoadSound(string filepath)
        {
            return SDL_mixer.Mix_LoadWAV(filepath);
        }
        public void PlaySound(IntPtr mySound)
        {
            SDL_mixer.Mix_PlayChannel(-1, mySound, 0);
        }

    }

    class Taimer
    {
        public Int32 taimer,pobrany_czas=0;
        public bool flaga=true;

        public Taimer(Int32 taimer)
        {
            this.taimer = taimer;
        }

        public void Start()
        {
            pobrany_czas = (Int32)SDL.SDL_GetTicks();
        }
        public void Sprawdzanie()
        {
            if (flaga == false)
            {
                
                Int32 i = (Int32)SDL.SDL_GetTicks() - pobrany_czas;
                if (i >= taimer)
                {
                    flaga = true;
                }
            }
        }
        public void Zakonczono()
        {
            flaga = false;
            pobrany_czas = 0;
            Start();
        }

    }
}
